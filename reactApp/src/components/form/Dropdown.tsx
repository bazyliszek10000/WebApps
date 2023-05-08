import * as React from 'react';
import { IDropdownProps } from './model';

export const Dropdown = (props: IDropdownProps) : JSX.Element => {

    const [selectedItem, setSelectedItem] = React.useState<string>();

    const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) : void => {
        e.preventDefault();
        
        const selectedValue = e.target.value;         
        
        setSelectedItem(selectedValue);
        if (selectedValue === props.defaultText) {
            props.onSelected(null);   
        }
        else {
            props.onSelected(e.target.value);
        }
    }

    const getItems = (): React.ReactNode[] => {
        return props.items.map(x => {
            return <option key={x.value} value={x.value}>{x.text}</option>
        });
    }

    return (        
            
        <select value={selectedItem} onChange={handleChange} className="form-select" aria-label="Default select example">
            <option>{props.defaultText}</option>
            {getItems()}
        </select>
    )
}