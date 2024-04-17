'use client';
import React, { useState, useEffect } from 'react';
//import axios from 'axios';

const Customers = () => {

    const [customers, setCustomers] = useState([]);
    const dataType = 1;

    useEffect(() => {
        /*fetch(`customers/${dataType}`)
            .then((results) => {
                return results.json();
            })
            .then(data => {
                setCustomers(customers);
            })*/
        const fetchData = async () => {
            try {
                const response = await axios.get('https://square6-crm-api.azurewebsites.net/Customer/all');
                setCustomers(response.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        //fetchData();
    }, []);

    return (
        <main>
            {
                (customers != null) ? customers.map((customer) => <h3> { customer.Name}</h3>):<div>Loading...</div>
            }
        </main>
    );
};

export default Customers;
