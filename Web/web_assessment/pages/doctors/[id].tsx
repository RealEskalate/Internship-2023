import React from 'react';
import { useRouter } from  'next/router';
import { useGetDoctorProfileQuery } from '@/store/features/doctors/doctors-api';

const DoctorProfile: React.FC = () => {
  const router = useRouter();
  const id = router.query.id;
  const { data: doctor, isLoading, isError } = useGetDoctorProfileQuery(id as string);
 
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error fetching todo</div>;
  }

  if (!doctor) {
    return <div>Todo not found</div>;
  }
  return (
    <div className="bg-white rounded-lg shadow-lg overflow-hidden">
      <div className="px-6 py-4">
        <div className="flex justify-center">
          <img className="h-32 w-32 rounded-full object-cover" src={doctor.photo} alt="Doctor Profile" />
        </div>
        <div className="mt-4">
          <h3 className="text-lg font-medium text-gray-900">{doctor.fullName}</h3>
          <p className="text-gray-600">Specialist in Cardiology</p>
        </div>
        <div className="mt-4">
          <h4 className="text-gray-900 font-medium">About</h4>
          <p className="text-gray-600">{doctor.summary}</p>
        </div>
        <div className="mt-4">
          <h4 className="text-gray-900 font-medium">Education</h4>
          <ul className="list-disc list-inside text-gray-600">
            <li>Doctor of Medicine, University of California, Los Angeles</li>
            <li>Bachelor of Science in Biology, University of California, Berkeley</li>
          </ul>
        </div>
        <div className="mt-4">
          <h4 className="text-gray-900 font-medium">Contact Info</h4>
          <ul className="list-disc list-inside text-gray-600">
            <li>Email: john.doe@hospital.com</li>
            <li>Phone: (123) 456-7890</li>
            <li>Address: 123 Main St, Los Angeles, CA 90001</li>
          </ul>
        </div>
      </div>
    </div>
  );
};
  

export default DoctorProfile