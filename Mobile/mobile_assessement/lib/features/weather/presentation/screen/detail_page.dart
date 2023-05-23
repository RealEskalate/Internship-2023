import 'package:flutter/material.dart';

class DetailPage extends StatelessWidget {
  final String cityName;
  final bool isFavorite;

  const DetailPage({
    required this.cityName,
    required this.isFavorite,
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFF5F4FF),
      body: Column(
        children: [
          Container(
            height: 60,
            width: double.infinity,
            padding: const EdgeInsets.only(left: 16, top: 16),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                IconButton(
                  icon: const Icon(Icons.arrow_back),
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(top: 16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        cityName,
                        style: const TextStyle(
                          color: Color(0xFF211772),
                          fontWeight: FontWeight.w700,
                          fontSize: 18,
                          fontFamily: 'Roboto',
                        ),
                      ),
                      IconButton(
                        onPressed: () {
                          // Handle favorite icon press
                        },
                        icon: Icon(
                          isFavorite ? Icons.favorite : Icons.favorite_border,
                          color: isFavorite ? Colors.red : Colors.grey,
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 8),
                const Padding(
                  padding: EdgeInsets.symmetric(horizontal: 16),
                  child: Text(
                    'Day, Month, Date',
                    style: TextStyle(
                      color: Color(0xFF211772),
                      fontSize: 16,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                ),
                const SizedBox(height: 16),
                Center(
                  child: Column(
                    children: [
                      Image.asset(
                        'assets/images/mostly_sunny.png', // Replace with the actual weather image
                        width: 120,
                        height: 120,
                      ),
                      const SizedBox(height: 8),
                      const Row(
                        mainAxisAlignment: MainAxisAlignment.start,
                        children: [
                          Padding(
                            padding: EdgeInsets.all(8.0),
                            child: Text(
                              'Mostly Sunny',
                              style: TextStyle(
                                color: Color(0xFF9F93FF),
                                fontSize: 18,
                                fontWeight: FontWeight.w500,
                                fontFamily: 'Roboto',
                              ),
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 8),
                      const Row(
                        mainAxisAlignment: MainAxisAlignment.start,
                        children: [
                          Padding(
                            padding: EdgeInsets.all(8.0),
                            child: Text(
                              '30°C', // Replace with the actual temperature
                              style: TextStyle(
                                color: Color(0xFF211772),
                                fontSize: 72,
                                fontWeight: FontWeight.w700,
                                fontFamily: 'Roboto',
                              ),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          Expanded(
            child: ListView.builder(
              padding: const EdgeInsets.all(16),
              itemCount: 10, // Replace with the actual number of rows
              itemBuilder: (context, index) {
                return Container(
                  decoration: const BoxDecoration(
                    color: Color(0xFF211772),
                  ),
                  child: buildWeatherRow(
                    'Day, Month, Date', // Replace with the actual date format
                    28, // Replace with the actual temperature
                    Icons.wb_sunny, // Replace with the actual weather icon
                  ),
                );
              },
            ),
          ),
        ],
      ),
    );
  }

  Widget buildWeatherRow(String date, int temperature, IconData iconData) {
    return Container(
      padding: const EdgeInsets.only(top: 16),
      child: Row(
        children: [
          Text(
            date,
            style: const TextStyle(
              color: Colors.white,
              fontSize: 16,
              fontWeight: FontWeight.w500,
            ),
          ),
          const Expanded(child: SizedBox()),
          Text(
            '$temperature°C',
            style: const TextStyle(
              color: Colors.white,
              fontSize: 16,
              fontWeight: FontWeight.w500,
            ),
          ),
          const SizedBox(
            width: 23,
          ),
          Text(
            '$temperature°C',
            style: const TextStyle(
              color: Colors.white,
              fontSize: 16,
              fontWeight: FontWeight.w500,
            ),
          ),
          const SizedBox(width: 8),
          Icon(
            iconData,
            color: Colors.white,
          ),
        ],
      ),
    );
  }
}
