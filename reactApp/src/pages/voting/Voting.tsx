import * as React from 'react';
import { IVotingGridData } from 'src/components/voting-grid/model';
import { VotingGrid } from 'src/components/voting-grid/VotingGrid';
import { VotePanel } from './components/vote-panel/VotePanel';
import { useVotingApp } from './useVoting';

export const Voting = () => {

    const {
        onVoted,
        voteService,
        candidateService
    } = useVotingApp();
    
    const votersGridData : IVotingGridData = {
        title: "Voters",
        leftHeader: "Name",
        rightHeader: "has voted",
        rows: voteService.gridData
    }

    const candidatesGridData : IVotingGridData = {
        title: "Candidates",
        leftHeader: "Name",
        rightHeader: "Votes",
        rows: candidateService.gridData
    }

    return (
        <div>
            <h1>Voting app</h1>
            <div className='container'>
                <div className='row'>
                    <div className='col-6'>
                        <VotingGrid data={votersGridData} onAdd={voteService.onAddVoter} />
                    </div>
                    <div className='col-6'>
                        <VotingGrid data={candidatesGridData} onAdd={candidateService.onAddCandidate} />
                    </div>
                </div>
                <div className='row'>                
                    <div className='col-12'>
                        <VotePanel onVoted={onVoted} data={{Voters: voteService.ableToVote, Candidates: candidateService.candidates}} />
                    </div>
                </div>
            </div>
        </div>
    )
}