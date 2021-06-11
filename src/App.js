import logo from './logo.svg';
import './App.css';

function App() {

  fetch("http://localhost:64551/api/values/GetEmployeeDetail", { headers: { "Content-Type": "application/json" } }).then(res => res.json())
  
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
