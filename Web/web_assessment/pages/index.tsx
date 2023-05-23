import Card from "@/components/Card";
import Search from "@/components/Search";
import {useFetchUserQuery} from "@/features/userSlice"
import Link from "next/link";
export default function Home() {
  const {data, isLoading, isError} = useFetchUserQuery();
  return (
    
    <main className="p-2">
      <Search />
      <div className="grid grid-cols-4 gap-4">
        {data &&
          data.data.map((item: any) => (
            <Link key={item._id} href={`/detail/${item._id}`}>
            <Card
              fullName={item.fullName}
              photo={item.photo}
              speciality={item.speciality[0].name}
              address={item.institutionID_list[0].institutionName}
            />
            </Link>
          ))}
      </div>
    </main>
  )
}
