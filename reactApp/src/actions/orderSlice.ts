import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "src/store";

interface order {
    name: string;
    price: number
}

interface IOrderState {
    orders: order[]
}

const initialState: IOrderState = {
    orders: [{
        name: "Karol",
        price: 700    
    }]
}

export const orderSlice = createSlice({
    name: "order",
    initialState,
    reducers: {
        addOrder: (state, action: PayloadAction<order>) => {
            state.orders = [...state.orders, action.payload]
        }
    }
});

export const firstOrder = (state: RootState) => { debugger; return state.orders.orders[0] };
export const { addOrder } = orderSlice.actions
export default orderSlice.reducer