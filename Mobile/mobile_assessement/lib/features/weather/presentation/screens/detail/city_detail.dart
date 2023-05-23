// import 'package:flutter/material.dart';

// class WeatherPage extends StatelessWidget {
//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Container(
//         width: double.infinity,
//         height: double.infinity,
//         color: Color(0xFFF2F2F2),
//         child: Stack(
//           children: [
//             Positioned(
//               width: 15.87,
//               height: 7.93,
//               left: 35,
//               top: 75,
//               child: Transform.rotate(
//                 angle: -90 * 0.0174533,
//                 child: Container(
//                   decoration: BoxDecoration(
//                     border: Border.all(
//                       color: Color(0xFF272727),
//                       width: 2,
//                     ),
//                     borderRadius: BorderRadius.circular(4),
//                   ),
//                 ),
//               ),
//             ),
//             Positioned(
//               width: 100,
//               height: 21,
//               left: 138,
//               top: 56,
//               child: Column(
//                 crossAxisAlignment: CrossAxisAlignment.center,
//                 children: [
//                   Text(
//                     'New Mexico',
//                     style: TextStyle(
//                       fontFamily: 'Roboto',
//                       fontWeight: FontWeight.w700,
//                       fontSize: 18,
//                       color: Color(0xFF211772),
//                     ),
//                     textAlign: TextAlign.center,
//                   ),
//                   SizedBox(height: 5),
//                   Text(
//                     'Sun, November 16',
//                     style: TextStyle(
//                       fontFamily: 'Roboto',
//                       fontWeight: FontWeight.w400,
//                       fontSize: 12,
//                       color: Color(0xFF575757),
//                     ),
//                     textAlign: TextAlign.center,
//                   ),
//                 ],
//               ),
//             ),
//             Positioned(
//               left: MediaQuery.of(context).size.width * 0.8267,
//               right: MediaQuery.of(context).size.width * 0.1133,
//               top: MediaQuery.of(context).size.height * 0.0685,
//               bottom: MediaQuery.of(context).size.height * 0.9082,
//               child: Container(
//                 decoration: BoxDecoration(
//                   border: Border.all(
//                     color: Color(0xFF000000),
//                     width: 2,
//                   ),
//                 ),
//               ),
//             ),
//             Positioned(
//               width: 98,
//               height: 17,
//               left: 138.5,
//               top: 78,
//               child: Container(
//                 child: Text(
//                   'Mostly Sunny',
//                   style: TextStyle(
//                     fontFamily: 'Roboto',
//                     fontWeight: FontWeight.w500,
//                     fontSize: 24,
//                     color: Color(0xFF9F93FF),
//                   ),
//                 ),
//               ),
//             ),
//             Positioned(
//               height: 84,
//               left: 0,
//               right: MediaQuery.of(context).size.width * 0.2589,
//               top: MediaQuery.of(context).size.height * 0.5 - 84 / 2 - 0.5,
//               child: Container(
//                 child: Text(
//                   '30',
//                   style: TextStyle(
//                     fontFamily: 'Roboto',
//                     fontWeight: FontWeight.w700,
//                     fontSize: 72,
//                     height: 1.17,
//                     color: Color(0xFF211772),
//                   ),
//                 ),
//               ),
//             ),
//             Positioned(
//               width: 375,
//               height: 323,
//               left: 0,
//               top: 538,
//               child: Container(
//                 decoration: BoxDecoration(
//                   color: Color(0xFF211772),
//                   boxShadow: [
//                     BoxShadow(
//                       offset: Offset(0, -4),
//                       blurRadius: 10,
//                       color: Color.fromRGBO(33, 23, 114, 0.203681),
//                     ),
//                   ],
//                   borderRadius: BorderRadius.only(
//                     topLeft: Radius