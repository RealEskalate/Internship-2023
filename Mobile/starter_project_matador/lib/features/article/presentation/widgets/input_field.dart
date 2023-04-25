import 'package:flutter/material.dart';

class InputField extends StatelessWidget {
  const InputField({Key? key, required this.labelText}) : super(key: key);
  final String labelText;

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return SizedBox(
      height: screenSize.height * 0.06,
      child: TextField(
        decoration: InputDecoration(
          labelText: labelText,
        ),
      ),
    );
  }
}


// import 'package:flutter/material.dart';

// class TitleWidget extends StatelessWidget {
//   const TitleWidget({Key? key}) : super(key: key);

//   @override
//   Widget build(BuildContext context) {
//     final Size screenSize = MediaQuery.of(context).size;

//     return SizedBox(
//       height: screenSize.height * 0.06,
//       child: const TextField(
//         decoration: InputDecoration(
//           labelText: 'Add Title',
//         ),
//       ),
//     );
//   }
// }
