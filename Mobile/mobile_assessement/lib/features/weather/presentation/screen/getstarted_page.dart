import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/search_page.dart';

class GetStartedPage extends StatelessWidget {
  const GetStartedPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        color: const Color(0xFF3C2DB9), // Background color: 3C2DB9
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Image.asset(
                'assets/images/rainy_lightning_windy_sunny.png', // Replace with your weather image asset
                width: 150,
                height: 150,
              ),
              const SizedBox(height: 20),
              const Text(
                'Weather',
                style: TextStyle(
                  fontSize: 44,

                  fontWeight: FontWeight.w500,
                  fontFamily: 'Roboto',
                  color: Color(0xFFFFBA25), // Color of "Weather": FFBA25
                ),
              ),
              const Text(
                'Forecast App',
                style: TextStyle(
                  fontSize: 36,
                  fontFamily: 'Roboto',
                  fontWeight: FontWeight.w500,
                  color: Colors.white, // Color of "Forecast App": White
                ),
              ),
              const SizedBox(height: 40),
              Container(
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10.0),
                ),
                width: 220,
                height: 48,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => const SearchCityPage()));
                    // Handle button press
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor:
                        const Color(0xFFFFBA25), // Button color: FFBA25
                  ),
                  child: const Text(
                    'Get Started',
                    style: TextStyle(
                        fontSize: 16,
                        fontFamily: 'Roboto',
                        fontWeight: FontWeight.w500),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
