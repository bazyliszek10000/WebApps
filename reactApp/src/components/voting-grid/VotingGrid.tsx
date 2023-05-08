import * as React from 'react';
import { AddVotingRowGridModal } from './AddVotingRowGridModal';
import { MemoizedItemItemVotingGrid } from './ItemVotingGrid';
import { IVotingGridProps, VotingRowGrid } from './model';
import './voting-grid.css';

export const VotingGrid = (props: IVotingGridProps): JSX.Element => {

    const [isModalOpened, setIsModalOpened] = React.useState<boolean>(false);

    const rows = React.useMemo((): JSX.Element[] => {
        return props.data.rows?.map(r => {
            return <MemoizedItemItemVotingGrid key={r.uniqueKey} {...r} />
        });
    }, [props]);

    const handleAddClick = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        setIsModalOpened(true);
    }

    const handleCloseClick = () => {
        setIsModalOpened(false);
    }

    const handleSaveClick = (row: VotingRowGrid) => {
        if (props.onAdd) {
            props.onAdd(row);
        }

        setIsModalOpened(false);
    }

    return (
        <div>
            <div className='container grid'>
                <div className='row grid-header'>
                    <div className='col'>
                        {props.data.title} <button onClick={handleAddClick}>[+]</button>
                    </div>
                </div>
                <div className='row grid-header'>
                    <div className='col grid-col'>
                        {props.data.leftHeader}
                    </div>
                    <div className='col'>
                        {props.data.rightHeader}
                    </div>
                </div>
                {rows}
            </div>
            { isModalOpened && <AddVotingRowGridModal header={"Add " + props.data.title} onClose={handleCloseClick} onSave={handleSaveClick} /> }
        </div>
    );
}