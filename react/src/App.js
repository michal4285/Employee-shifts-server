import Register from './components/Register/Register'
import Login from './components/Login/Login'
import './App.css';

function App() {

  fetch("http://localhost:64551/api/employee", {
    headers: { "Content-Type": "application/json" },
    method: "POST",
    body: JSON.stringify({})
  })
    .then(res => res.json())

  return (
    <>
      <Login />
      <Register />
    </>
  );
}

export default App;
