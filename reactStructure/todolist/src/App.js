import logo from './logo.svg';
import './App.css';
import Card from './components/Card';
import { useEffect, useState } from 'react';

function App() {
  const mockData = [
    { description: 'Descrição do card 1' },
    { description: 'Descrição do card 2' }
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
          <input placeholder="Procurar tarefa" className="Input-card"></input>
          {/* <img src="" alt="Search in the list" /> */}
          <div>
            {mockData.map((card, index) => (
              <Card key={index} {...card} />
            ))}
          </div>
        </section>
        <button placeholder="Nova tarefa" className="New-card"/>
      </main>
    </div>
  );
}

export default App;
