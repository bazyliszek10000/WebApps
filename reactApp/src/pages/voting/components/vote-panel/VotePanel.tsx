import * as React from 'react';
import { Dropdown } from 'src/components/form/Dropdown';
import { IDropdownItemData } from 'src/components/form/model';
import { IVotePanelProps } from './model';

export const VotePanel = (props: IVotePanelProps): JSX.Element => {

    const [selectedVoter, setSelectedVoter] = React.useState<string|null>();
    const [selectedCandidate, setSelectedCandidate] = React.useState<string|null>();

    const handleVoteClick = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        
        if(props.onVoted && selectedVoter && selectedCandidate) {
            props.onVoted(selectedVoter, selectedCandidate);
            setSelectedVoter(null);
        }
    }

    const handleVoterSelected = (value: string|null): void => {        
        setSelectedVoter(value);
    }

    const handleCandidateSelected = (value: string|null): void => {
        setSelectedCandidate(value);
    }
    
    const votersDropdownData = React.useMemo<IDropdownItemData[]>((): IDropdownItemData[] => {
        return props.data.Voters.map(v => {
            return {
                text: v.name,
                value: v.id.toString()
            }
        })
    }, [props.data.Voters]);

    const candidatesDropdownData = React.useMemo<IDropdownItemData[]>((): IDropdownItemData[] => {
        return props.data.Candidates.map(v => {
            return {
                text: v.name,
                value: v.id.toString()
            }
        })
    }, [props.data.Candidates]);

    return (
        <div>
            <div>
                <h2>Vote!</h2>
            </div>
            <div className='container'>
                <div className='row'>
                    <div>
                        <Dropdown onSelected={handleVoterSelected} defaultText="I am" items={votersDropdownData} />
                    </div>
                    <div>
                        <Dropdown onSelected={handleCandidateSelected} defaultText="I vote for" items={candidatesDropdownData} />
                    </div>
                    <div>
                        <button disabled={!selectedVoter || !selectedCandidate} onClick={handleVoteClick}>Vote</button>
                    </div>
                </div>
            </div>
        </div>
    )
}