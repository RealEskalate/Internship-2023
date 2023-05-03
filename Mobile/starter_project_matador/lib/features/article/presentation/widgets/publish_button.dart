import 'package:flutter/material.dart';

class PublishButton extends StatelessWidget {
  const PublishButton({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;
    final bool isPortrait = MediaQuery.of(context).orientation == Orientation.portrait;

    return Center(
      child: SizedBox(
        width: isPortrait ? screenSize.width * 0.3 : screenSize.width * 0.15,
        height: screenSize.height * 0.06,
        child: ElevatedButton(
          onPressed: () {},
          style: ElevatedButton.styleFrom(
            shadowColor: Colors.blue,
            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
                  ),
                  child: const Text('Publish', style: TextStyle(fontSize: 20)),
                ),
              ),
            );
    }
}