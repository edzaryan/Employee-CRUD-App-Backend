import './App.css'
import { Routes, Route } from 'react-router-dom'

import Employee from './components/Employee'
import EmployeeDetails from './components/EmployeeDetails'
import Department from './components/Department'

import NotFound from './components/NotFound'

import Layout from './components/Layout'

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={ <Layout /> }>
          <Route index element={ <Employee /> } />
          <Route path="employee/:id" element={ <EmployeeDetails /> } />
          <Route path="departments" element={ <Department /> } />
          
          <Route path="*" element={ <NotFound /> } />
        </Route>
      </Routes>
    </>
  )
}

export default App
