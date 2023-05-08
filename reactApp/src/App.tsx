import * as React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Orders } from './pages/shop/orders/orders';

export default function App() {
    return (
        <div className='container'>
            <div className='row'>
                <div className='col'>
                    {/* <Voting/> */}
                    <Orders />
                </div>
            </div>
        </div>
    );
}