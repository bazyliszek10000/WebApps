import * as React from "react";
import { IItemVotingGridProps } from "./model";

export const ItemVotingGrid = (props: IItemVotingGridProps): JSX.Element => {
    return (
        <div className='row'>
            <div className='col'>
                {props.leftColumn}
            </div>
            <div className='col'>
                {props.rightColumn}
            </div>
        </div>
    );
}

export const MemoizedItemItemVotingGrid = React.memo(ItemVotingGrid);