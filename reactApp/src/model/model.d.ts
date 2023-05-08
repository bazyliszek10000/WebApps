export interface Voter {
    id: number,
    name: string,
    candidateId? : number | undefined
}

export interface Candidate {
    id: number,
    name: string
}