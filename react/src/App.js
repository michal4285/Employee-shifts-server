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

//   const SignIn=()=>{
//   debugger;
//   fetch(`http://localhost:64551/api/employee/Get`, {
//     method: 'GET',
//     // body: JSON.stringify({})
// })
//   .then(res => res.json()).then(data=>{console.log(data) 
//     if(data)
//     setuser(data)}).catch(err=>console.log(err.message))
// }
  return (
    <>
      <Login />
      <Register />
    </>
  );
}

export default App;
