import { Voter } from "src/model/model"

enum VotersActionTypes {
    Init = "INIT_VOTER",
    Add = "ADD_VOTER",
    Voted = "VOTED_VOTER",
}

export interface VotersAction {
    type: VotersActionTypes,
    payload: Voter[]
}

export const addVoterAction = (voter: Voter[]): VotersAction => {
    return {
        type: VotersActionTypes.Add,
        payload: voter
    }
}

export const votedVoterAction = (voter: Voter[]): VotersAction => {
    return {
        type: VotersActionTypes.Voted,
        payload: voter
    }
}

export const initialVoterAction = (voters: Voter[]): VotersAction => {
    return {
        type: VotersActionTypes.Init,
        payload: voters
    }
}

export const votersReducer = (state: Voter[], action: VotersAction) => {
    switch (action.type) {
        case VotersActionTypes.Init:
            return [...action.payload]

        case VotersActionTypes.Add:
            return [
                ...state,
                ...action.payload
            ]

        case VotersActionTypes.Voted: {
            const voter = action.payload[0];
            return state.map(v => {
                if (v.id === voter.id) {
                    return {
                        ...v,
                        candidateId: voter.candidateId
                    }
                }
                return v;
            });
        }

        default:
            return state;
    }
}

export const createInitialVotersState: Voter[] = [];