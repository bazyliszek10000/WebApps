export interface AddVotingRowGridModalProps {
    header: string;
    onClose(): void;
    onSave(row: VotingRowGrid): void;
}

export interface VotingRowGrid {
    name: string
}

export interface IVotingGridProps {
    onAdd(row: VotingRowGrid): void;
    data: IVotingGridData
}

export interface IVotingGridData {
    title: string,
    leftHeader: string;
    rightHeader: string;
    rows: IItemVotingGridProps[];
}

export interface IItemVotingGridProps {
    uniqueKey: string
    leftColumn: string;
    rightColumn: string;
}