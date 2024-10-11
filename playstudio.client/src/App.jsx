import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [gameClubs, setGameClubs] = useState();

  useEffect(() => {
    populateGameClubsData();
  }, []);

  const contents =
    gameClubs === undefined ? (
      <p>
        <em>
          Loading... Please refresh once the ASP.NET backend has started. See{" "}
          <a href="https://aka.ms/jspsintegrationreact">
            https://aka.ms/jspsintegrationreact
          </a>{" "}
          for more details.
        </em>
      </p>
    ) : (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {gameClubs.map((gameClub) => (
            <tr key={gameClub.id}>
              <td>{gameClub.name}</td>
              <td>{gameClub.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );

  return (
    <div>
      <h1 id="tableLabel">Play Studio Game Clubs and Events</h1>
      <h3>Game Clubs</h3>
      {contents}
      <h3>Events</h3>
    </div>
  );

  async function populateGameClubsData() {
      const result = [{
            id: 1,
            name: "Liverpool FC",
            description: "hello"
      }]
      // const res = await fetch('/gameclub/clubs');
      // console.log(res);
      setGameClubs(result);
  }
}

export default App;
