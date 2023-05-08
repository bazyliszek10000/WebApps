import { Candidate, Voter } from "src/model/model";

export interface IVotePanelProps {
    data: IVotePanelData,
    onVoted: (voter: string, candidate: string) => void
}

export interface IVotePanelData {
    Voters: Voter[];
    Candidates: Candidate[];
}