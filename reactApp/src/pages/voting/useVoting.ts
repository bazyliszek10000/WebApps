import axios from 'axios';
import * as React from 'react';
import { IItemVotingGridProps, VotingRowGrid } from 'src/components/voting-grid/model';
import { Candidate, Voter } from "src/model/model"
import { addVoterAction, createInitialVotersState, initialVoterAction, votedVoterAction, votersReducer } from './reducers/votersReducer';

export const useVotingApp = () => {
    const [voters, votersDispatch] = React.useReducer(votersReducer, createInitialVotersState);
    const [candidates, setCandidates] = React.useState<Candidate[]>([]);

    React.useEffect(() => {
        fetchCandidates();
        fetchVoters();
    }, []);

    const fetchCandidates = () => {
        axios.get('https://localhost:7207/api/Candidates')
            .then((response): void => {
                setCandidates(response.data as Candidate[]);
            })
            .catch((error): void => {
                console.log(error);
            })
    }

    const fetchVoters = async(): Promise<void> => {
        try {
            const response = await axios.get('https://localhost:7207/api/Voters');
            votersDispatch(initialVoterAction(response.data as Candidate[]))
        } catch (error) {
            console.log(error);
        }
    }

    const handleAddVoter = (row: VotingRowGrid): void => {
        axios.post('https://localhost:7207/api/Voters', row)
            .then((response): void => {
                const voterId = response.data as number;
                const voter: Voter = { 
                    id: voterId,
                    name: row.name,                  
                };
                votersDispatch(addVoterAction([voter]))
            })
            .catch((error) : void => {
                console.log(error);
            })
    }

    const handleAddCandidate = async (row: VotingRowGrid): Promise<void> => {
        try {
            const response = await axios.post('https://localhost:7207/api/Candidates', row);
            const candidateId = response.data as number;
            const candidate: Candidate = {
                id: candidateId,
                name: row.name
            };
            setCandidates([...candidates, candidate])
        } catch (error) {
            console.log(error);
        }
    }

    const handleVoted = async(voterId: string, candidateId: string): Promise<void> => {
        try {
            const params = new URLSearchParams({
                voterId: voterId,
                candidateId: candidateId
            });
            await axios.put(`https://localhost:7207/api/Voters/Vote?${params}`);
            votersDispatch(votedVoterAction([{
                id: parseInt(voterId),
                name: "",
                candidateId: parseInt(candidateId) 
            }]));

        } catch (error) {
            console.log(error);
        }
    }

    const votersGridData = React.useMemo<IItemVotingGridProps[]>((): IItemVotingGridProps[] => {
        return voters.map(v => {
            return {
                uniqueKey: v.id.toString(),
                leftColumn: v.name,
                rightColumn: v.candidateId ? "V" : "X"
            }
        });
    }, [voters]);
    const candidatesGridData = React.useMemo<IItemVotingGridProps[]>((): IItemVotingGridProps[] => {
        return candidates.map(c => {
            return {
                uniqueKey: c.id.toString(),
                leftColumn: c.name,
                rightColumn: voters.filter(v => v.candidateId === c.id).length.toString()
            }
        })
    }, [voters, candidates]);

    const ableToVote = React.useMemo(() =>
        voters.filter(v => !v.candidateId)
        , [voters])

    return {
        voteService: {
            ableToVote: ableToVote,
            gridData: votersGridData,
            onAddVoter: handleAddVoter
        },
        candidateService: {
            candidates: candidates,
            gridData: candidatesGridData,
            onAddCandidate: handleAddCandidate
        },
        onVoted: handleVoted
    }
}