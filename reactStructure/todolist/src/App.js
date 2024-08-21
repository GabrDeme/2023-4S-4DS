import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';
import TaskList from './components/List/List';
import Card from './components/Card/Card';

function App() {
  const mockData = [
    { description: 'Descrição do card 1' },
    { description: 'Descrição do card 2' },
    { description: 'Faz o L' },
    { description: 'Faz o L' },
    { description: 'Faz o L' },
    { description: 'Faz o L' },
    { description: 'Faz o L' }
  ];

  const [today, setToday] = useState(new Date());

  useEffect(() => {
    const intervalId = setInterval(() => {
      setToday(new Date());
    }, 60000);

    return () => clearInterval(intervalId);
  }, []);

  return (
    <div className="App">
      <main className="App-body">
        <section className="List-card">
          <h1>
            {today.toLocaleDateString()}
          </h1>
          <input placeholder="Search task" className="Input-card"></input>
          {/* <img src="" alt="Search in the list" /> */}
          {/* <ul>
            <div>
              {mockData.map((card, index) => (
                <Card key={index} {...card} />
              ))}
            </div>
          </ul> */}
          <TaskList/>
        </section>
        <button className="New-card">
          New task
        </button>
      </main>
    </div>
  );
}

export default App;
