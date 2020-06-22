using System;
using System.Collections.Generic;
using Tfi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class PawnController: MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public Vector3 initPos;
        public Player player;
        private Transform startParent;

        void Start()
        {
            initPos = transform.localPosition;
            initPos = new Vector3(initPos.x, initPos.y, -1);
        }


        private void Update()
        {
            if (player.getCards().Count > 5 && DiscardController.player == null && !GridController.endIsDisplay)
            {
                DiscardController.player = this.player;
                SceneManager.LoadSceneAsync("Discard", LoadSceneMode.Additive);
            }

        }

        public void OnDrag(PointerEventData eventData)
        {
            Island modele = player.GetModele();
            if (modele.isMovable(player))
            {
                Vector3 mousePos = Input.mousePosition;

                if (Camera.main != null)
                {

                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(transform.position.x, transform.position.y, 100);

                }
            }
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,100);
            Island modele = player.GetModele();
            if (Camera.main != null && modele.isMovable(player))
            {
                Vector3 worldPosition1;

                worldPosition1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition1.z = -1 * worldPosition1.z;
                RaycastHit2D hit = Physics2D.Raycast(transform.position,  -Vector2.up);
                if (hit.collider != null)
                {
                    print(hit.collider.name);
                    if (hit.collider.name == "ZoneNormal(Clone)(Clone)")
                    {
                        ZoneController zc = hit.collider.GetComponent<ZoneController>();
                        Zone zone = zc.GetZone();
                        if (modele.getRoundOf().Equals(player))
                        {
                            List<Zone> listZones = player.zonesSafeToMove();

                            if (listZones.Contains(zone) && player.canAct() && zone != player.getZone())
                            {
                                
                                float tileSize = GridController.tileSize;
                                /*transform.localPosition = zc.LocalPosPawn();
                                initPos = transform.localPosition;*/
                                player.movePlayer(zone, zc);
                                player.addAction();
                            }
                            else
                            {
                                print("Mouvement interdit");
                                transform.localPosition = initPos;
                            }
                        }
                        else
                        {
                            Player navigateur = modele.getRoundOf();
                            List<Zone> listZones = Navigateur.zonesReachableNavigateur(modele, player.getZone().getPosition());
                            if (listZones.Contains(zone) && navigateur.canAct() && zone != player.getZone()) {
                                player.movePlayer(zone, zc); // on bouge l'autre joueur
                                navigateur.addAction(); // on incremente l'action du navigateur
                                

                            } else
                                print("Mouvement interdit");
                        }
                    }else
                        transform.localPosition = initPos;
                }
                else
                {
                    transform.localPosition = initPos;
                }
                    
            }
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,-1);


        }

        public void movePawn(ZoneController zc)
        {
            transform.localPosition = zc.LocalPosPawn();
            initPos = transform.localPosition;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,-1);

        }
        

        public void SetPlayer(Player player)
        {
            this.player = player;
            player.setPawnContrller(this);
        }
    }
}