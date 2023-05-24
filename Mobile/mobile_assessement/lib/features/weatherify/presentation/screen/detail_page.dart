import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weatherify/domain/entity/weather_entity.dart';

class DetailPage extends StatelessWidget {
  final Weather weather;
  const DetailPage({super.key, required this.weather});


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(weather.cityName
        ),
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
          Image.network(weather.cloud,
            height: 200,
            width: double.infinity,
            fit: BoxFit.cover,
          ),
          SizedBox(height: 16),
          Text(
            weather.maxtemperature.toString(),
            style: TextStyle(fontSize: 20),
          ),
          SizedBox(height: 16),
          Expanded(
            child: ListView.builder(
              itemCount: 7,
              itemBuilder: (context, index) {
                return ListTile(
                  trailing: Image.network(
                    weather.cloud,
                    fit: BoxFit.cover,
                  ),
                  title: Text(weather.date),
                  subtitle: Row(
                    children: [
                      Text(weather.mintemperature.toString()),
                      Text(weather.maxtemperature.toString()),
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