import logo from './logo.svg';
import './App.css';
import React, {useEffect} from "react";
import axios from "axios";

function App() {

  useEffect(() => {
    axios.post("https://localhost:5001/api/v2/WeatherForecast?city=Oslo")
        .then(response => console.log(response))
        .catch(({message})=> console.log({message}))
  },[])

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
