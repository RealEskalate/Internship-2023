import React from 'react';
import Image from 'next/image';
import { Inter } from 'next/font/google';
import DoctorCard from '@/components/DoctorCard';

export default function Home() {
  const doctorsData = [];

  for (let i = 0; i < 16; i++) {
    const institutionData = {
      _id: "1",
      address: {
        region: "Region",
        summary: "Summary",
        woreda: "Woreda",
        zone: "Zone",
      },
      availability: {
        twentyFourHours: false,
        startDay: "Monday",
        endDay: "Friday",
        opening: "09:00",
        closing: "18:00",
      },
      institutionType: "Hospital",
      establishedOn: "2010-01-01",
      institutionName: "Hospital Name",
      location: {
        type: "Point",
        coordinates: [0, 0],
      },
      lang: { am: "Language" },
    };

    const doctorData = {
      _id: `${i + 1}`,
      emails: [`doctor${i + 1}@example.com`],
      photo: "path/to/photo.jpg",
      summary: `I am doctor ${i + 1}.`,
      speciality: [
        {
          _id: "1",
          isSubspeciality: false,
          name_fuzzy: [`specialty ${i + 1}`],
          name: "Specialty",
          created_at: "2022-01-01",
          updated_at: "2022-01-02",
          __v: 1,
          lang: { am: `Specialty ${i + 1}` },
        },
      ],
      experience_years: 5,
      institutionID_list: [institutionData], // Updated type annotation here
      gender: "Male",
      languages: ["English"],
      birthday: "1990-01-01",
      otherDocuments: [],
      experience: [],
      fullName: `Dr. John Doe ${i + 1}`,
      mainInstitution: "1",
      education: [],
      availablity: [],
      __v: 1,
      fullName_fuzzy: [`Dr. John Doe ${i + 1}`],
    };

    doctorsData.push(doctorData);
  }

  return (
    <main>
      <div className="grid grid-cols-4 gap-4">
        {doctorsData.map((doctorData) => (
          <div key={doctorData._id} className="col-span-1">
            <DoctorCard doctor={doctorData} />
          </div>
        ))}
      </div>
    </main>
  );
}
