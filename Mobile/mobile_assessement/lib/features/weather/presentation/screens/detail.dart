import 'package:flutter/material.dart';

import '../../domain/entities/weather.dart';

class DetailPage extends StatefulWidget {
  final Weather weather;
  const DetailPage({super.key, required this.weather});

  @override
  State<DetailPage> createState() => _DetailPageState();
}

class _DetailPageState extends State<DetailPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromRGBO(242, 242, 242, 1.0),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            padding: const EdgeInsets.only(top: 40, left: 16, right: 16),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                IconButton(
                  icon: const Icon(Icons.arrow_back),
                  onPressed: () {
                    // Handle back button press
                  },
                ),
                const SizedBox(width: 16),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: const [
                    Text(
                      'New Mexico',
                      style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(33, 23, 114, 1)),
                    ),
                    Text(
                      'Sun, November 16',
                      style: TextStyle(fontSize: 14),
                    ),
                  ],
                ),
                IconButton(
                    onPressed: () {}, icon: const Icon(Icons.favorite_border))
              ],
            ),
          ),
          const SizedBox(height: 26),
          Center(
            child: Image.asset(
              'assets/images/sunny_cloud.png', // Replace with your sunny image asset
              width: 150,
              height: 150,
            ),
          ),
          const SizedBox(height: 26),
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: const [
                Text(
                  'Mostly Sunny',
                  style: TextStyle(fontSize: 18),
                ),
                Text(
                  '30°',
                  style: TextStyle(
                    fontSize: 38,
                    fontWeight: FontWeight.bold,
                    color: Color.fromRGBO(33, 23, 114, 1),
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(height: 16),
          Expanded(
            child: Card(
              color: const Color.fromRGBO(33, 23, 114, 1),
              shape: const RoundedRectangleBorder(
                borderRadius: BorderRadius.vertical(
                  top: Radius.circular(25),
                ),
              ),
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text(
                      'Every day',
                      style: TextStyle(fontSize: 20, color: Colors.white),
                    ),
                    Expanded(
                      child: ListView.builder(
                        itemCount: 5, // Replace with the actual number of rows
                        itemBuilder: (context, index) {
                          return ListTile(
                            leading: const Text(
                              'Mon, Nov 17',
                              style:
                                  TextStyle(fontSize: 18, color: Colors.white),
                            ),
                            trailing: Row(
                              mainAxisSize: MainAxisSize.min,
                              children: const [
                                Text('33°',
                                    style: TextStyle(
                                        fontSize: 18, color: Colors.white)),
                                SizedBox(width: 8),
                                Text('24°',
                                    style: TextStyle(
                                        fontSize: 18, color: Colors.white)),
                                SizedBox(width: 8),
                                Icon(
                                  Icons.cloud,
                                  color: Colors.white,
                                ),
                              ],
                            ),
                          );
                        },
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
