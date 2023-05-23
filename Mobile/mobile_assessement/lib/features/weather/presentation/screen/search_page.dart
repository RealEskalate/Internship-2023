import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/detail_page.dart';

class SearchCityPage extends StatefulWidget {
  const SearchCityPage({Key? key}) : super(key: key);

  @override
  State<SearchCityPage> createState() => _SearchCityPageState();
}

class _SearchCityPageState extends State<SearchCityPage> {
  List<String> cities = [
    'New Mexico, USA',
    'Paris, France',
    'Barcelona, Spain'
  ];
  List<double> temprature = [28, 24, 36];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF5F4FF),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const Center(
              child: Text(
                'Choose City',
                style: TextStyle(
                  color: Color(0xFF211772),
                  fontWeight: FontWeight.w700,
                  fontSize: 18,
                  fontFamily: 'Roboto',
                ),
              ),
            ),
            const SizedBox(height: 31),
            const SizedBox(height: 8),
            Row(
              children: [
                Expanded(
                  child: Container(
                    decoration: BoxDecoration(
                      color: Colors.white,
                      border: Border.all(color: Colors.grey),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: const TextField(
                      decoration: InputDecoration(
                        border: InputBorder.none,
                        focusedBorder: InputBorder.none,
                        hintText: 'Search a new city...',
                        prefixIcon: Icon(
                          Icons.search,
                          color: Colors.grey,
                          // Replace with desired icon color
                        ),
                      ),
                    ),
                  ),
                ),
                const SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    // Handle search button press
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color(0xFFFFBA25),
                  ),
                  child: const Text("Search"),
                ),
              ],
            ),
            const SizedBox(height: 16),
            const Text(
              'My Favorite Cities',
              style: TextStyle(
                color: Color(0xFF211772),
                fontSize: 16,
                fontWeight: FontWeight.w400,
              ),
            ),
            const SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: 3, // Replace with the actual count of cities
                itemBuilder: (context, index) {
                  return Padding(
                    padding: const EdgeInsets.only(bottom: 16),
                    child: buildCityRow(
                      cities[index], // Replace with the actual city name
                      temprature[index], // Replace with the actual temperature
                      Icons.wb_sunny,
                      const Color(0xFFFFBA25),
                    ),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget buildCityRow(
    String cityName,
    double temperature,
    IconData iconData,
    Color color,
  ) {
    return Container(
      color: Colors.white,
      child: ListTile(
        title: TextButton(
          onPressed: () => {
            Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => DetailPage(
                    cityName: cityName,
                    isFavorite: true,
                  ),
                )),
          },
          child: Row(
            children: [
              const SizedBox(width: 8),
              Text(
                cityName,
                style: const TextStyle(
                  color: Color(0xFF575757),
                  fontFamily: 'Roboto',
                  fontSize: 16,
                  fontWeight: FontWeight.w500,
                ),
              ),
              const Expanded(child: SizedBox()),
              Text(
                '$temperature°C',
                style: const TextStyle(
                  color: Color(0xFF211772),
                  fontSize: 24,
                  fontWeight: FontWeight.w500,
                  fontFamily: 'Roboto',
                ),
              ),
              const SizedBox(width: 20),
              Icon(iconData, color: color),
            ],
          ),
        ),
      ),
    );
  }
}
