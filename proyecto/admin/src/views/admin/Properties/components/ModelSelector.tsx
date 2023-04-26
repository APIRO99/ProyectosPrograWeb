import { useRef, useState, useEffect } from 'react';
import { Canvas, useFrame, useThree } from 'react-three-fiber';
import { Box, Box as Box3D } from '@react-three/drei';
import THREE, { Mesh } from 'three';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';

function Model({ gltf }: { gltf: any }) {
  if (!gltf) return (<></>);
  console.log(gltf);
  return (
    <mesh>
      <primitive 
        object={gltf.scene} 
        scale={[0.4,0.4,0.4]}
        position={[0, -1, 0]}
      />
    </mesh>
  );
}


const PropertyModel = () => {
  const [rotation, setRotation] = useState<[number, number, number]>([0, 0, 0]);
  const [model, setModel] = useState(null);
  const boxRef = useRef<Mesh>();
  const { camera } = useThree();
  const loader = new GLTFLoader();

  useFrame(() => {
    if (boxRef.current) {
      setRotation([rotation[0], rotation[1] + 0.004, rotation[2]]);
      boxRef.current.rotation.set(...rotation);
    }
  });
  useEffect(() => {
    camera.position.set(0, 3, 4);
    camera.lookAt(0, 0, 0);
    // loader.load('/assets/models/modernHouse/house.gltf', (gltf) => {
    loader.load('/assets/models/ISR1.glb', (gltf) => {
      setModel(gltf);
    });
  }, []);

  return (
    <>
      <mesh ref={boxRef}>
        <Model gltf={model} />
      </mesh>
    </>
  );
}


const Wrapper = () => {
  return (
    <Canvas style={{ width: "100%", height: '400px' }}>
      <ambientLight />
      <pointLight position={[10, 10, 10]} />
      <PropertyModel />
    </Canvas>
  )
}

export default Wrapper;