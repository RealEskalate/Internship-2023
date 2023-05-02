import 'package:flutter/material.dart';

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
                      color: Color.fromARGB(255, 209, 209, 207),),
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
                      color: Color.fromARGB(255, 209, 209, 207),
                      fontSize: 16,
                      ),
                  ),
                ),
              ),
      ],
    );
  }
}