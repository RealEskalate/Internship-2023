import Card from "@/components/Card";
import {useFetchUserMutation} from "@/features/userSlice"
import { useEffect } from "react";
export default function Home() {
  const [fetchUser, { data, isLoading, isError }] = useFetchUserMutation();
  useEffect(() => {
    fetchUser();
  }, [fetchUser]);
  console.log(data ?? "");
  // const {...,firstName, } = data.data  

  return (
    
    <main className="">
      <div>
        Hello
      </div>
      {data?.map(()=><Card />)}
    </main>
  )
}
