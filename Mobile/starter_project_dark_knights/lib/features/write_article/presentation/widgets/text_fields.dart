import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class AddTitleAndSubtitle extends StatelessWidget {
  const AddTitleAndSubtitle({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
          child: TextFormField(
            decoration: const InputDecoration(
              border: UnderlineInputBorder(),
              labelText: 'Add title',
              labelStyle: TextStyle(
                fontFamily: 'Poppins',
                color: textFieldTextColor,
              ),
            ),
          ),
        ),
        Container(
          margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
          child: TextFormField(
            decoration: const InputDecoration(
              border: UnderlineInputBorder(),
              labelText: 'Add subtitle',
              labelStyle: TextStyle(
                fontFamily: 'Poppins',
                color: textFieldTextColor,
                fontSize: 16,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
