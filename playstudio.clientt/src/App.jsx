import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [clubs, setClubs] = useState([]);
  const [events, setEvents] = useState([])
  const [param, setParam] = useState('');

  useEffect(() => {
    populateClubs()
  }, [])

  const populateClubs = async () => {
    const response =  await fetch("http://localhost:5157/gameclub/clubs")
    const clubs = await response.json()
    setClubs(clubs)

    if (clubs && clubs.length > 0){
      populateEvents(clubs[0].id)
    }
  }

  const populateEvents = async (clubId) => {
    const response =  await fetch(`http://localhost:5157/eventclub/clubs/${clubId}/events`)
    const events = await response.json()
    setEvents(events)
  }

  const handleOnClick = async () => {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ param: param })
    };
    const response =  await fetch(`http://localhost:5157/gameclub/clubs/search`, requestOptions)
    const clubs = await response.json()
    setClubs(clubs)
  }

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Game Club</h1>
      <input 
        placeholder="Enter club name or description"
        onChange={(event) => {console.log(event.target.value); setParam(event.target.value)}}
      />
      <button onClick={() => handleOnClick()}>Search</button>
      <div>
        <table>
          <thead>
            <tr>
              <th>Club</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            {clubs.map((gameClub) => (
              <tr key={gameClub.id}>
                <td>{gameClub.name}</td>
                <td>{gameClub.description}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <h1>Game Events</h1>
      <div>
        <table>
          <thead>
            <tr>
              <th>Title</th>
              <th>Description</th>
              <th>Scheduled Date Time</th>
            </tr>
          </thead>
          <tbody>
            {events.map((event) => (
              <tr key={event.id}>
                <td>{event.title}</td>
                <td>{event.description}</td>
                <td>{event.scheduledDateTime}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  )
}

export default App
