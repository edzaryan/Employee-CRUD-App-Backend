import React from 'react'
import { NavLink } from 'react-router-dom'

function Navbar() {
  return (
    <div className='container flex mb20'>
      <NavLink to="/" className="p10">Home</NavLink>   
      <NavLink to="/departments" className="p10">Department</NavLink>
    </div>
  )
}

export default Navbar