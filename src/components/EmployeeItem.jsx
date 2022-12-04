
import React from 'react'

function EmployeeItem({ propName, value }) {
  return (
    <div>
        <div className='fw6 fs20'>{ propName }</div>
        <div className='ptb5'>{ value }</div>
    </div>
  )
}

export default EmployeeItem