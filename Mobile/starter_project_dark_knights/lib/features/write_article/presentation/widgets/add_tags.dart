import '../../../../core/utils/colors.dart';

import 'package:flutter/material.dart';

class TagSelector extends StatefulWidget {
  @override
  _TagSelectorState createState() => _TagSelectorState();
}

class _TagSelectorState extends State<TagSelector> {
  final tagController = TextEditingController();

  @override
  void dispose() {
    // Clean up the controller when the widget is disposed.
    tagController.dispose();
    super.dispose();
  }

  final List<String> _tags = [];

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
      child: Stack(
        children: [
          Align(
            alignment: Alignment.center,
            child: Container(
              margin: const EdgeInsets.fromLTRB(0, 0, 10, 0),
              padding: const EdgeInsets.fromLTRB(0, 0, 40, 0),
              child: Column(
                children: [
                  TextFormField(
                    controller: tagController,
                    decoration: const InputDecoration(
                      border: UnderlineInputBorder(),
                      labelText: 'Add Tags',
                      labelStyle: TextStyle(
                        fontFamily: 'Poppins',
                        color: whiteColor,
                      ),
                    ),
                  ),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Container(
                      padding: const EdgeInsets.fromLTRB(0, 5, 0, 0),
                      child: const Text(
                        'add as many tags as you want',
                        style: TextStyle(
                          fontFamily: 'Poppins',
                          color: whiteColor,
                          fontSize: 10,
                        ),
                      ),
                    ),
                  ),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Container(
                      margin: const EdgeInsets.fromLTRB(0, 15, 0, 0),
                      child: Wrap(
                        spacing: 14.0,
                        runSpacing: 10.0,
                        children: <Widget>[
                          for (var i in _tags)
                            Chip(
                              deleteIcon: const CircleAvatar(
                                backgroundColor:
                                    Color.fromRGBO(55, 106, 237, 0.15),
                                child: Icon(
                                  Icons.close,
                                  color: primaryColor,
                                  size: 14,
                                ),
                              ),
                              onDeleted: () {
                                setState(() {
                                  _tags.remove(i);
                                });
                              },
                              deleteIconColor: primaryColor,
                              backgroundColor: whiteColor,
                              label: Text(i),
                              labelStyle: const TextStyle(
                                color: primaryColor,
                                fontFamily: 'Poppins',
                                fontWeight: FontWeight.w500,
                              ),
                              shape: const StadiumBorder(
                                  side: BorderSide(
                                width: 2,
                                color: primaryColor,
                              )),
                            ),
                        ],
                      ),
                    ),
                  )
                ],
              ),
            ),
          ),
          Align(
            alignment: Alignment.centerRight,
            child: Container(
              padding: const EdgeInsets.fromLTRB(0, 0, 0, 33),
              child: IconButton(
                onPressed: () {
                  setState(() {
                    _tags.add(tagController.text);
                  });
                },
                icon: const Icon(
                  Icons.add_circle_outline,
                  color: primaryColor,
                  size: 35,
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
