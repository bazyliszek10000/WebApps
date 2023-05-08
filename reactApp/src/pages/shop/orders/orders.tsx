import * as React from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { firstOrder, addOrder } from "src/actions/orderSlice";
import { RootState } from "src/store";

export const Orders = (): JSX.Element => {

    const orderState = useSelector((state: RootState) => state.orders)
    const firstOrderState = useSelector(firstOrder);
    const dispatch = useDispatch();

    return (
        <div>
            {firstOrderState?.name}
            
            { 
                orderState.orders.map(x => (
                    <div key={x.price}>{x.name} {x.price}</div>
                ))
            }
            
            <button onClick={() => { dispatch(addOrder({ name: "To jest tra zmiana", price: Date.now()}))}}>Message</button>
        </div>
    )
}