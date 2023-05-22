import { useGetSuccessRatesQuery } from '@/store/features/home/home-api'
import YearlySuccess from './YearlySuccess'
import { YearlySuccessRate } from '@/types/home/success-rate'
interface SuccessProp {
  info: YearlySuccessRate
}

const SuccessCard= () => {
  const { data : success =[], isLoading, error } = useGetSuccessRatesQuery()
  
  return (
    <div className="flex flex-col items-center w-full grow sm:flex-row sm:justify-center">
      {success.map((info) => (
        <div className="flex flex-col items-center justify-center w-3/5 p-5 m-4 bg-white rounded-xl aspect-auto grow">
        <p className="mb-4 font-bold">{info.year}</p>
        <p className="font-bold">{info.success}</p>
        <p className="text-sm text-secondary-text">{info.average}</p>
      </div>
      ))}
    </div>
  )
}

export default SuccessCard