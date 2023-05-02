import 'package:flutter/material.dart';
import '../../../../core/utils/constants/global_variables.dart';

class InputFormField extends StatelessWidget {
  final bool password;
  const InputFormField({Key? key, required this.password}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        TextField(
          obscureText: password,
        ),
        if (password)
          const Align(
            alignment: Alignment.centerRight,
            child: TextButton(
                onPressed: null,
                child: Text(
                  'Show',
                  style: TextStyle(color: primaryColor, fontFamily: 'Urbanist'),
                )),
          ),
        if (password == false)
          const TextField(
            decoration: InputDecoration(
                hintText: 'jonathandavies@gmail.com',
                hintStyle:
                    TextStyle(color: placeholderColor, fontFamily: 'Urbanist')),
          ),
      ],
    );
  }
}
