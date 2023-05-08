export interface IDropdownProps {
    defaultText: string;
    items: IDropdownItemData[];
    onSelected: (value: string|null) => void; 
}

export interface IDropdownItemData {
    text: string,
    value: string,
}