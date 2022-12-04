import React from 'react'
import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'

function Employee() {
    const [employee, setEmployee] = useState(null)

    useEffect(() => {
        axios
            .get('employees')
            .then(response => {
                setEmployee(response.data)
            })
            .catch(err => console.log(err.message))
    }, [])

    return (
        <div>
            <div className='centering'>
                <table className='tbl'>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Name</th>
                            <th>Surname</th>
                            <th>Department</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        employee && employee.map(e => (
                            <tr key={ e.id }>
                                <td className='flex fjc'>
                                    <span className='tblImg' style={{ backgroundImage: `url(${e.image})`}}></span>
                                </td>
                                <td>{ e.name }</td>
                                <td>{ e.surname }</td>
                                <td>{ e.department }</td>
                                <td>
                                    <Link className='btn b-blue' to={`/employee/${e.id}`}>Details</Link>
                                </td>
                            </tr>
                        ))
                    }
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default Employee
