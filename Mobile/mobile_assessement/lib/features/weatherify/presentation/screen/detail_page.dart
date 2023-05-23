import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weatherify/domain/entity/weather_entity.dart';

class DetailPage extends StatelessWidget {
  final Weather weather;

  const DetailPage({super.key, required this.weather});


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(weather.cityName),
        actions: [
          IconButton(
            icon: Icon(Icons.favorite_border),
            onPressed: () {},
          ),
        ],
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Image.network(
            'https://source.unsplash.com/random/800x600',
            height: 200,
            width: double.infinity,
            fit: BoxFit.cover,
          ),
          SizedBox(height: 16),
          Text(
            weather.maxtemperature as String,
            style: TextStyle(fontSize: 20),
          ),
          SizedBox(height: 16),
          Expanded(
            child: ListView.builder(
              itemCount: 7,
              itemBuilder: (context, index) {
                return ListTile(
                  trailing: Image.network(
                    'https://source.unsplash.com/random/100x100',
                    fit: BoxFit.cover,
                  ),
                  title: Text(weather.date),
                  subtitle: Row(
                    children: [
                      Text(weather.maxtemperature as String),
                      Text(weather.mintemperature as String),
                    ],
                  ),
                );
              },
            ),
          ),
        ],
      ),
    );
  }
}