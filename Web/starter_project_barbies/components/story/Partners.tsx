import { useGetCompaniesQuery } from '@/store/story/companies-api'
import Image from 'next/image'
import { Company } from './../../types/story'

const Partners = () => {
  const { data: partners, isError, isLoading } = useGetCompaniesQuery()

  if (isError) {
    return <div>Error: {isError.toString()}</div>
  }

  if (partners === undefined || isLoading) {
    return <div>Loading...</div>
  }

  return (
    <div className="flex flex-col text-center text-40 lg:mt-20 lg:mx-0 md:mt-40">
      <h2 className="font-DM Sans mr-40 lg:mr-20 md:mr-10 text-3xl">
        Current Interview Partners
      </h2>
      <div className="flex flex-wrap mx-80 lg:mx-60  md:mx-5  justify-evenly gap-5 text-2xl mt-20">
        {partners.map((partner: Company, index: number) => (
          <div key={index} className="w-40 mb-5">
            <Image
              width={150}
              height={150}
              src={partner?.image}
              alt="logo"
              priority
            />
          </div>
        ))}
      </div>
    </div>
  )
}

export default Partners
