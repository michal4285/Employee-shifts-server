import Register from './components/Register/Register'
import Login from './components/Login/Login'
import './App.css';

function App() {

  fetch("http://localhost:64551/api/values/GetEmployeeDetail", { headers: { "Content-Type": "application/json" } }).then(res => res.json())

  return (
    <>
    <Login/>
    <Register/>
    </>
  );
}

export default App;
