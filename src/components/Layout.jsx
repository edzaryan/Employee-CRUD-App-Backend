import { Outlet } from 'react-router-dom'
import Navbar from './Navbar'

const Layout = () => {
    return (
        <>
            <Navbar />
            
            <main className='container'>
                <Outlet />
            </main>

            <footer className='container'>2021</footer>
        </>
    )
}

export default Layout