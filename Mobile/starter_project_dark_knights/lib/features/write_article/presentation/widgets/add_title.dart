import 'package:flutter/material.dart';

class AddTitle extends StatelessWidget {
  const AddTitle({super.key});

  @override
  Widget build(BuildContext context) {
    return  Container(
                margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
                
                child: TextFormField(
                  decoration: const InputDecoration(
                    border: UnderlineInputBorder(),
                    labelText: 'Add title',
                    labelStyle: TextStyle(
                      fontFamily: 'Poppins',
                      color: Color.fromARGB(255, 209, 209, 207),),
                  ),
                ),
              );
  }
}