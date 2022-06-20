import './App.css';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import PostsPage from './components/pages/PostsPage';
import Footer from './components/Footer/Footer'

function App() {
  return (
    <>
    <Router>
      <Navbar/>
        <Routes>
          <Route path='/' exact element={<PostsPage />}/>
        </Routes>
        <Footer />
    </Router>
    </>
  );
}

export default App;
