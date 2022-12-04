
import React from 'react'
import { useState, useEffect } from 'react'
import axios from 'axios'

function Department() {
    const [departments, setDepartments] = useState(null)

    useEffect(() => {
        axios
            .get('/departments')
            .then(res => setDepartments(res.data))
            .catch(err => console.log(err.message))
    }, [])

    return (
        <div>
            <div className='centering'>
                <table className='tbl'>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        { departments && departments.map(d => (
                            <tr key={d.id}>
                                <td>{ d.name }</td>
                                <td>
                                    <span className='btn b-blue mr5'>Edit</span>
                                    <span className='btn b-red'>Delete</span>
                                </td>
                            </tr>
                        )) }
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default Department