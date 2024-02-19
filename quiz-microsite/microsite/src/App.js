import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Authenticate from "./components/Authenticate";
import Layout from "./components/Layout";
// import Login from "./components/Login";
import Quiz from "./components/Quiz";
import Result from "./components/Result";
import NewSystemInfo from "./components/NewSystemInfo";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* <Route path="/" element={<Login />} /> */}
        <Route path="/" element={<NewSystemInfo />} />
        <Route element={<Authenticate />}>
          <Route path="/" element={<Layout />}>
            <Route path="/quiz" element={<Quiz />} />
            <Route path="/result" element={<Result />} />
            <Route path="/systeminfo" element={<NewSystemInfo />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
