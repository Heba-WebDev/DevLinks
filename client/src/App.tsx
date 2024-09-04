import { Button } from "./components/ui/button";
import { useAppSelector } from "./hooks/store";

function App() {
  const user = useAppSelector((state) => state.user);
  return (
    <>
      <h1 className="text-2xl text-orange-700">Hola ${user.firstName} ${user.lastName}</h1>
      <h2>{user.accessToken} || no token</h2>
      <Button className=" bg-blue-200">Click me</Button>
    </>
  );
}

export default App
