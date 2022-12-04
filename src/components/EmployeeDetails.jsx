import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import EmployeeItem from './EmployeeItem'

function EmployeeDetails() {
  let { id } = useParams()
  const [employee, setEmployee] = useState(null)

  useEffect(() => {
    axios
      .get(`/employees/${id}`)
      .then(res => {
        setEmployee(res.data)
      })
      .catch(err => console.log(err.message))
  }, [id])

  return (
    <> {
      employee && (<div className='flx fjb'>
                    <div className='w200 mr30'>
                      <div className='profileImg' style={{ backgroundImage: `url(${employee.image})`}}></div>
                    </div>
                    <div className='ff1'>
                      <div className='fs25 mb20 fw7 '>Employee Details</div>
                      <EmployeeItem propName="Name" value={ employee.name } />
                      <EmployeeItem propName="Surname" value={ employee.surname } />
                      <EmployeeItem propName="Email" value={ employee.email } />
                      <EmployeeItem propName="Department" value={ employee.department } />
                      <EmployeeItem propName="Phone Number" value={ employee.phoneNumber } />
                      <EmployeeItem propName="Salary" value={ employee.salary } />
                      <EmployeeItem propName="Description" value={ employee.description } />
                    </div>
                  </div>)
      }
    </>
  )
}

export default EmployeeDetails