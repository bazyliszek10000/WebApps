import * as React from 'react';
import { Modal } from 'react-bootstrap';
import { SubmitHandler, useForm } from 'react-hook-form';
import { AddVotingRowGridModalProps } from './model';

interface IFormInput {
    name: string,
}

export const AddVotingRowGridModal = (props: AddVotingRowGridModalProps) => {

    const handleCloseClick = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();

        if (props.onClose) {
            props.onClose();
        }
    }

    const { register, handleSubmit, formState: { errors } } = useForm<IFormInput>();

    const handleOnSubmit: SubmitHandler<IFormInput> = (data: IFormInput) => {
        if (props.onSave) {
            props.onSave({name: data.name});
        }
    }

    return (
        <Modal show={true}>
            <Modal.Header closeButton>
                <Modal.Title>{props.header}</Modal.Title>
            </Modal.Header>
            <Modal.Body>                
                <form onSubmit={handleSubmit(handleOnSubmit)}>
                    <div>
                        <div>
                            Name:
                            <input {...register("name", { required: true })} />      
                        </div>
                        <div style={{color: 'red'}}>
                            {errors.name && "First name is required"}
                        </div>
                    </div>
                    <div>
                        <button type='button' onClick={handleCloseClick} style={{margin: '20px'}}>
                            Close
                        </button>
                        <button type='submit' style={{margin: '20px'}}>
                            Save Changes
                        </button>
                    </div>
                </form>
            </Modal.Body>
        </Modal>
    );
}