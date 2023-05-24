// import 'package:flutter/material.dart';
// import 'package:mobile_assessement/features/weather/presentation/screen/home.dart';

// class OnboardingPage extends StatelessWidget {
//   const OnboardingPage({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(

//       body: SafeArea(
//         child: Column(
//           children: [
//             const Expanded(
//               flex: 2,
//               child: Placeholder(),
//               // Container(
//               //   decoration: const BoxDecoration(
//               //     image: DecorationImage(
//               //       image: AssetImage('assets/images/onboarding_image.png'),
//               //       fit: BoxFit.cover,
//               //     ),
//               //   ),
//               // ),
//             ),
//             Expanded(
//               flex: 1,
//               child: Container(
//                 padding: const EdgeInsets.all(16.0),
//                 child: Column(
//                   mainAxisAlignment: MainAxisAlignment.center,
//                   children: [
//                     const Text(
//                       'Welcome to Weather App',
//                       style: TextStyle(
//                         fontSize: 24.0,
//                         fontWeight: FontWeight.bold,
//                       ),
//                     ),
//                     const SizedBox(height: 16.0),
//                     ElevatedButton(
//                       onPressed: () {
//                         Navigator.push(
//                             context,
//                             MaterialPageRoute(
//                                 builder: (context) => HomePage()));
//                       },
//                       child: const Text('Get Started'),
//                     ),
//                   ],
//                 ),
//               ),
//             ),
//           ],
//         ),
//       ),
//     );
//   }
// }

import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/screen/home.dart';

class OnboardingPage extends StatelessWidget {
  const OnboardingPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color(0xFF3B7DE3),
      body: SafeArea(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            Container(
              width: double.infinity,
              height: MediaQuery.of(context).size.height * 0.5,
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/Group.png'),
                  fit: BoxFit.contain,
                ),
              ),
            ),
            Column(
              children: [
                const Text(
                  'Welcome to Weather App',
                  style: TextStyle(
                    fontSize: 24.0,
                    fontWeight: FontWeight.bold,
                    color: Colors.white,
                  ),
                ),
                const SizedBox(height: 16.0),
                ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => HomePage()));
                  },
                  child: const Text('Get Started'),
                  style: ElevatedButton.styleFrom(
                    primary: Colors.white,
                    onPrimary: Color(0xFF3B7DE3),
                    textStyle: TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.bold,
                    ),
                    padding: EdgeInsets.symmetric(horizontal: 40, vertical: 12),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(30),
                    ),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}